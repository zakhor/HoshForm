using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace HoshForm
{
    public partial class HoshForm : Form
    {
        public HoshForm()
        {
            InitializeComponent();
            AllocConsole();
        }

        //コンソールを使用
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static long ToUnixTime(DateTime dt)
        {
            var dto = new DateTimeOffset(dt.Ticks, new TimeSpan(+09, 00, 00));
            return dto.ToUnixTimeSeconds();
        }

        private static void Wait(int Seconds)
        {
            for (int i = 1; i <= Seconds; i++)
            {
                Thread.Sleep(1000);
                Console.Write("{0:D4}", Seconds - i);
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.Beep();
        }

        private static string Read(string Url, Encoding enc)
        {
            Stream st = client.OpenRead(Url);
            StreamReader sr = new StreamReader(st, enc);
            string Result = sr.ReadToEnd();
            sr.Close();
            st.Close();
            return Result;
        }

        //WebClient起動
        public static WebClient client = new WebClient();
        //ChromeDriverOptions宣言
        public static ChromeOptions options = new ChromeOptions();
        private void btnStart_Click(object sender, EventArgs e)
        {
            //各変数を取得
            string UrlBoard = tbUrlBoard.Text;
            string Target = tbTarget.Text;
            string TimeInterval = tbTimeInterval.Text;
            string HN = tbHN.Text;
            string Message = tbMessage.Text;

            this.Close();

            //正規表現を用意
            string Pattern1 = "https://(?<Server>.+?).5ch.net/(?<Board>.+?)/";
            string Pattern2 = "<a href=\"(?<Number>[0-9]{10}/l50)\">.+?" + Target + ".+?</a>";
            string Pattern3 = "data-date=\"(?<Date>[0-9]+)\"";
            string Pattern4 = "<input class=\"formelem maxwidth\" placeholder=\"名前(省略可)\" name=\"FROM\" size=\"70\">";


            //各変数を出力
            Console.Write
                (
                "UrlBoard:\t" + UrlBoard + "\r\n" +
                "Target:\t\t" + Target + "\r\n" +
                "TimeInterval:\t" + TimeInterval + "\r\n" +
                "HN:\t\t" + Name + "\r\n" +
                "Message:\t" + Message + "\r\n"
                );

            //エンコードの指定
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            //スレ一覧とスレのURLの設定
            string UrlThreadList = UrlBoard + "subback.html";
            Match match = Regex.Match(UrlThreadList, Pattern1);
            string UrlThreadBase = "https://" + match.Groups["Server"] + ".5ch.net/test/read.cgi/" + match.Groups["Board"] + "/";

            //初期待ち時間を投稿間隔時間に設定
            long TimeWait = long.Parse(TimeInterval);

            //ずっと繰り返す
            while (true)
            {
                //スレ一覧の読み込み
                string Result = Read(UrlThreadList, enc);

                //目標のスレを取得
                MatchCollection Threads = Regex.Matches(Result, Pattern2);

                //目標のスレが存在しなければ待機
                if (Threads.Count == 0)
                {
                    Console.WriteLine
                       (
                        "THREAD NOT FOUND" + "\r\n" +
                        "TimeWait:\t" + TimeWait + "\r\n" +
                        "WAIT" + "\r\n"
                        );
                    //待機
                    Wait((int)TimeWait);
                }
                //目標のスレが存在するならスレを開く
                else
                {
                    Console.WriteLine("THREAD FOUND");
                    //スレを開く
                    string ThreadNumber = Threads[0].Result("${Number}").Replace("l50", "l0");
                    string UrlThread = UrlThreadBase + ThreadNumber;
                    Console.WriteLine("UrlThread:\t" + UrlThread);
                    Result = Read(UrlThread, enc);
                    //dat落ちを判定
                    while (Result.Contains(Pattern4))
                    {
                        //もしdat落ちでないなら最終書込時刻を取得
                        Console.WriteLine("THREAD NOT ARCHIEVED");
                        MatchCollection Dates = Regex.Matches(Result, Pattern3);
                        long DateLatest = long.Parse(Dates[Dates.Count - 1].Result("${Date}"));
                        DateTime TargetTime = DateTime.Now;
                        long DateNow = ToUnixTime(TargetTime) + 60 * 60 * 9;
                        long TimeDiff = DateNow - DateLatest;
                        //最終書込時刻と現在時刻、その差分を出力
                        Console.Write
                            (
                            "DateLatest:\t" + DateLatest + "\r\n" +
                            "DateNow:\t" + DateNow + "\r\n" +
                            "TimeDiff:\t" + TimeDiff + "\r\n"
                           );
                        //もし最終書込時刻から投稿間隔以上の時間が経過していれば書き込む
                        if (TimeDiff >= long.Parse(TimeInterval))
                        {
                            Console.WriteLine("POST");
                            TimeWait = long.Parse(TimeInterval);
                            //ChromeDriver起動
                            options.AddArgument("--headless");
                            options.AddArgument("--incognito");
                            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), options);
                            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                            driver.Url = UrlThread;
                            IWebElement Element = driver.FindElement(By.Name("FROM"));
                            Element.SendKeys(HN);
                            Element = driver.FindElement(By.Name("mail"));
                            Element.SendKeys(TimeInterval.ToString() + "秒");
                            Element = driver.FindElement(By.Name("MESSAGE"));
                            Element.SendKeys(Message);
                            Element = driver.FindElement(By.Name("submit"));
                            Element.Click();
                            //Cookie切れ対応
                            try
                            {
                                Element = driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@value=\"上記全てを承諾して書き込む\"]")));
                                Element.Click();
                            }
                            catch (WebDriverTimeoutException)
                            {
                            }
                            //ChromeDriver終了
                            driver.Close();
                        }
                        //もし最終書込時刻が投稿間隔時間内にあれば超過予想時刻まで待機
                        else
                        {
                            Console.WriteLine("NOT POST");
                            TimeWait = long.Parse(TimeInterval) - TimeDiff;
                        }
                        //待機時間を出力
                        Console.Write
                            (
                            "TimeWait:\t" + TimeWait + "\r\n" +
                            "WAIT\n"
                            );
                        //待機
                        Wait((int)TimeWait);
                        //スレを開く
                        Result = Read(UrlThread, enc);
                    }
                    //待機時間を出力
                    Console.Write
                        (
                        "THREAD ARCHIEVED" + "\r\n" +
                        "TimeWait:\t" + TimeWait + "\r\n" +
                        "WAIT\n"
                        );
                    //待機
                    Wait((int)TimeWait);
                }
            }
        }
    }
}
