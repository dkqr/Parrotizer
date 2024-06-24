using System;
using System.Timers;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Parrotizer {

    class Rainbow {
        public static String RgbToAnsii(int r, int g, int b) {
            return "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
        }
        public static String GetRainbow(Char c, int o) {
            String[] colours = {
                RgbToAnsii(255, 0, 0),
                RgbToAnsii(255, 127, 0),
                RgbToAnsii(255, 255, 0),
                RgbToAnsii(127, 255, 0),
                RgbToAnsii(0, 255, 0),
                RgbToAnsii(0, 255, 127),
                RgbToAnsii(0, 255, 255),
                RgbToAnsii(0, 127, 255),
                RgbToAnsii(0, 0, 255),
                RgbToAnsii(127, 0, 255),
                RgbToAnsii(255, 0, 255),
                RgbToAnsii(255, 0, 127),
            };
            return colours[o % colours.Length] + c;
        }
        public static string stringToRainbow(string s, int o) {
            string built = "";
            for (int i = 0; i < s.Length; i++) {
                built += GetRainbow(s[i], o);
            }
            return built;
        }
    }
    class PARROTIZER {

        string[] p0, p1, p2, p3, p4, p5, p6, p7, p8, p9;
        // frames taken from here :
        // https://github.com/hugomd/parrot.live/tree/master/frames
        public PARROTIZER() {
            p0 = new string[18] {   "                         .cccc;;cc;';c.           ",
                                    "                      .,:dkdc:;;:c:,:d:.          ",
                                    "                     .loc'.,cc::c:::,..;:.        ",
                                    "                   .cl;....;dkdccc::,...c;        ",
                                    "                  .c:,';:'..ckc',;::;....;c.      ",
                                    "                .c:'.,dkkoc:ok:;llllc,,c,';:.     ",
                                    "               .;c,';okkkkkkkk:;lllll,:kd;.;:,.   ",
                                    "               co..:kkkkkkkkkk:;llllc':kkc..oNc   ",
                                    "             .cl;.,oxkkkkkkkkkc,:cll;,okkc'.cO;   ",
                                    "             ;k:..ckkkkkkkkkkkl..,;,.;xkko:',l'   ",
                                    "            .,...';dkkkkkkkkkkd;.....ckkkl'.cO;   ",
                                    "         .,,:,.;oo:ckkkkkkkkkkkdoc;;cdkkkc..cd,   ",
                                    "      .cclo;,ccdkkl;llccdkkkkkkkkkkkkkkkd,.c;     ",
                                    "     .lol:;;okkkkkxooc::coodkkkkkkkkkkkko'.oc     ",
                                    "   .c:'..lkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkd,.oc     ",
                                    "  .lo;,:cdkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkd,.c;     ",
                                    ",dx:..;lllllllllllllllllllllllllllllllllc'...     ",
                                    "cNO;........................................      ",};
            p1 = new string[18] {  "                .ckx;'........':c.                ",
                                            "             .,:c:::::oxxocoo::::,',.             ",
                                            "            .odc'..:lkkoolllllo;..;d,             ",
                                            "            ;c..:o:..;:..',;'.......;.            ",
                                            "           ,c..:0Xx::o:.,cllc:,'::,.,c.           ",
                                            "           ;c;lkXKXXXXl.;lllll;lKXOo;':c.         ",
                                            "         ,dc.oXXXXXXXXl.,lllll;lXXXXx,c0:         ",
                                            "         ;Oc.oXXXXXXXXo.':ll:;'oXXXXO;,l'         ",
                                            "         'l;;kXXXXXXXXd'.'::'..dXXXXO;,l'         ",
                                            "         'l;:0XXXXXXXX0x:...,:o0XXXXx,:x,         ",
                                            "         'l;;kXXXXXXXXXKkol;oXXXXXXXO;oNc         ",
                                            "        ,c'..ckk0XXXXXXXXXX00XXXXXXX0:;o:.        ",
                                            "      .':;..:do::ooookXXXXXXXXXXXXXXXo..c;        ",
                                            "    .',',:co0XX0kkkxxOXXXXXXXXXXXXXXXOc..;l.      ",
                                            "  .:;'..oXXXXXXXXXXXXXXXXXXXXXXXXXXXXXko;';:.     ",
                                            ".ldc..:oOXKXXXXXXKXXKXXXXXXXXXXXXXXXXXXXo..oc     ",
                                            ":0o...:dxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxo,.:,     ",
                                            "cNo........................................;'     ",};
            p2 = new string[18] {  "            .cc;.  ...  .;c.                      ",
                                            "         .,,cc:cc:lxxxl:ccc:;,.                   ",
                                            "        .lo;...lKKklllookl..cO;                   ",
                                            "      .cl;.,:'.okl;..''.;,..';:.                  ",
                                            "     .:o;;dkd,.ll..,cc::,..,'.;:,.                ",
                                            "     co..lKKKkokl.':lloo;''ol..;dl.               ",
                                            "   .,c;.,xKKKKKKo.':llll;.'oOxl,.cl,.             ",
                                            "   cNo..lKKKKKKKo'';llll;;okKKKl..oNc             ",
                                            "   cNo..lKKKKKKKko;':c:,'lKKKKKo'.oNc             ",
                                            "   cNo..lKKKKKKKKKl.....'dKKKKKxc,l0:             ",
                                            "   .c:'.lKKKKKKKKKk;....lKKKKKKo'.oNc             ",
                                            "     ,:.'oxOKKKKKKKOxxxxOKKKKKKxc,;ol:.           ",
                                            "     ;c..'':oookKKKKKKKKKKKKKKKKKk:.'clc.         ",
                                            "   ,xl'.,oxo;'';oxOKKKKKKKKKKKKKKKOxxl:::;,.      ",
                                            "  .dOc..lKKKkoooookKKKKKKKKKKKKKKKKKKKxl,;ol.     ",
                                            "  cx,';okKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKl..;lc.   ",
                                            "  co..:dddddddddddddddddddddddddddddddddl::',::.  ",
                                            "  co...........................................   ",};
            p3 = new string[18] {  "           .ccccccc.                              ",
                                            "      .,,,;cooolccoo;;,,.                         ",
                                            "     .dOx;..;lllll;..;xOd.                        ",
                                            "   .cdo;',loOXXXXXkll;';odc.                      ",
                                            "  ,ol:;c,':oko:cccccc,...ckl.                     ",
                                            "  ;c.;kXo..::..;c::'.......oc                     ",
                                            ",dc..oXX0kk0o.':lll;..cxxc.,ld,                   ",
                                            "kNo.'oXXXXXXo',:lll;..oXXOo;cOd.                  ",
                                            "KOc;oOXXXXXXo.':lol;..dXXXXl';xc                  ",
                                            "Ol,:k0XXXXXX0c.,clc'.:0XXXXx,.oc                  ",
                                            "KOc;dOXXXXXXXl..';'..lXXXXXo..oc                  ",
                                            "dNo..oXXXXXXXOx:..'lxOXXXXXk,.:; ..               ",
                                            "cNo..lXXXXXXXXXOolkXXXXXXXXXkl,..;:';.            ",
                                            ".,;'.,dkkkkk0XXXXXXXXXXXXXXXXXOxxl;,;,;l:.        ",
                                            "  ;c.;:''''':doOXXXXXXXXXXXXXXXXXXOdo;';clc.      ",
                                            "  ;c.lOdood:'''oXXXXXXXXXXXXXXXXXXXXXk,..;ol.     ",
                                            "  ';.:xxxxxocccoxxxxxxxxxxxxxxxxxxxxxxl::'.';;.   ",
                                            "  ';........................................;l'   ",};
            p4 = new string[18] {  "                                                  ",
                                            "        .;:;;,.,;;::,.                            ",
                                            "     .;':;........'co:.                           ",
                                            "   .clc;'':cllllc::,.':c.                         ",
                                            "  .lo;;o:coxdllllllc;''::,,.                      ",
                                            ".c:'.,cl,.'l:',,;;'......cO;                      ",
                                            "do;';oxoc;:l;;llllc'.';;'.,;.                     ",
                                            "c..ckkkkkkkd,;llllc'.:kkd;.':c.                   ",
                                            "'.,okkkkkkkkc;lllll,.:kkkdl,cO;                   ",
                                            "..;xkkkkkkkkc,ccll:,;okkkkk:,co,                  ",
                                            "..,dkkkkkkkkc..,;,'ckkkkkkkc;ll.                  ",
                                            "..'okkkkkkkko,....'okkkkkkkc,:c.                  ",
                                            "c..ckkkkkkkkkdl;,:okkkkkkkkd,.',';.               ",
                                            "d..':lxkkkkkkkkxxkkkkkkkkkkkdoc;,;'..'.,.         ",
                                            "o...'';llllldkkkkkkkkkkkkkkkkkkdll;..'cdo.        ",
                                            "o..,l;'''''';dkkkkkkkkkkkkkkkkkkkkdlc,..;lc.      ",
                                            "o..;lc;;;;;;,,;clllllllllllllllllllllc'..,:c.     ",
                                            "o..........................................;'     ",};
            p5 = new string[18] {  "                                                  ",
                                            "           .,,,,,,,,,.                            ",
                                            "         .ckKxodooxOOdcc.                         ",
                                            "      .cclooc'....';;cool.                        ",
                                            "     .loc;;;;clllllc;;;;;:;,.                     ",
                                            "   .c:'.,okd;;cdo:::::cl,..oc                     ",
                                            "  .:o;';okkx;';;,';::;'....,:,.                   ",
                                            "  co..ckkkkkddkc,cclll;.,c:,:o:.                  ",
                                            "  co..ckkkkkkkk:,cllll;.:kkd,.':c.                ",
                                            ".,:;.,okkkkkkkk:,cclll;.ckkkdl;;o:.               ",
                                            "cNo..ckkkkkkkkko,.;loc,.ckkkkkc..oc               ",
                                            ",dd;.:kkkkkkkkkx;..;:,.'lkkkkko,.:,               ",
                                            "  ;:.ckkkkkkkkkkc.....;ldkkkkkk:.,'               ",
                                            ",dc..'okkkkkkkkkxoc;;cxkkkkkkkkc..,;,.            ",
                                            "kNo..':lllllldkkkkkkkkkkkkkkkkkdcc,.;l.           ",
                                            "KOc,c;''''''';lldkkkkkkkkkkkkkkkkkc..;lc.         ",
                                            "xx:':;;;;,.,,...,;;cllllllllllllllc;'.;od,        ",
                                            "cNo.....................................oc        ",};
            p6 = new string[18] {  "                                                  ",
                                            "                                                  ",
                                            "                   .ccccccc.                      ",
                                            "               .ccckNKOOOOkdcc.                   ",
                                            "            .;;cc:ccccccc:,:c::,,.                ",
                                            "         .c;:;.,cccllxOOOxlllc,;ol.               ",
                                            "        .lkc,coxo:;oOOxooooooo;..:,               ",
                                            "      .cdc.,dOOOc..cOd,.',,;'....':l.             ",
                                            "      cNx'.lOOOOxlldOc..;lll;.....cO;             ",
                                            "     ,do;,:dOOOOOOOOOl'':lll;..:d:''c,            ",
                                            "     co..lOOOOOOOOOOOl'':lll;.'lOd,.cd.           ",
                                            "     co.'dOOOOOOOOOOOo,.;llc,.,dOOc..dc           ",
                                            "     co..lOOOOOOOOOOOOc.';:,..cOOOl..oc           ",
                                            "   .,:;.'::lxOOOOOOOOOo:'...,:oOOOc.'dc           ",
                                            "   ;Oc..cl'':lldOOOOOOOOdcclxOOOOx,.cd.           ",
                                            "  .:;';lxl''''':lldOOOOOOOOOOOOOOc..oc            ",
                                            ",dl,.'cooc:::,....,::coooooooooooc'.c:            ",
                                            "cNo.................................oc            ",};
            p7 = new string[18] {  "                                                  ",
                                            "                                                  ",
                                            "                                                  ",
                                            "                        .cccccccc.                ",
                                            "                  .,,,;;cc:cccccc:;;,.            ",
                                            "                .cdxo;..,::cccc::,..;l.           ",
                                            "               ,do:,,:c:coxxdllll:;,';:,.         ",
                                            "             .cl;.,oxxc'.,cc,.';;;'...oNc         ",
                                            "             ;Oc..cxxxc'.,c;..;lll;...cO;         ",
                                            "           .;;',:ldxxxdoldxc..;lll:'...'c,        ",
                                            "           ;c..cxxxxkxxkxxxc'.;lll:'','.cdc.      ",
                                            "         .c;.;odxxxxxxxxxxxd;.,cll;.,l:.'dNc      ",
                                            "        .:,''ccoxkxxkxxxxxxx:..,:;'.:xc..oNc      ",
                                            "      .lc,.'lc':dxxxkxxxxxxxol,...',lx:..dNc      ",
                                            "     .:,',coxoc;;ccccoxxxxxxxxo:::oxxo,.cdc.      ",
                                            "  .;':;.'oxxxxxc''''';cccoxxxxxxxxxxxc..oc        ",
                                            ",do:'..,:llllll:;;;;;;,..,;:lllllllll;..oc        ",
                                            "cNo.....................................oc        ",};
            p8 = new string[18] {  "                                                  ",
                                            "                                                  ",
                                            "                              .ccccc.             ",
                                            "                         .cc;'coooxkl;.           ",
                                            "                     .:c:::c:,,,,,;c;;,.'.        ",
                                            "                   .clc,',:,..:xxocc;'..c;        ",
                                            "                  .c:,';:ox:..:c,,,,,,...cd,      ",
                                            "                .c:'.,oxxxxl::l:.,loll;..;ol.     ",
                                            "                ;Oc..:xxxxxxxxx:.,llll,....oc     ",
                                            "             .,;,',:loxxxxxxxxx:.,llll;.,,.'ld,   ",
                                            "            .lo;..:xxxxxxxxxxxx:.'cllc,.:l:'cO;   ",
                                            "           .:;...'cxxxxxxxxxxxxoc;,::,..cdl;;l'   ",
                                            "         .cl;':,'';oxxxxxxdxxxxxx:....,cooc,cO;   ",
                                            "     .,,,::;,lxoc:,,:lxxxxxxxxxxxo:,,;lxxl;'oNc   ",
                                            "   .cdxo;':lxxxxxxc'';cccccoxxxxxxxxxxxxo,.;lc.   ",
                                            "  .loc'.'lxxxxxxxxocc;''''';ccoxxxxxxxxx:..oc     ",
                                            "olc,..',:cccccccccccc:;;;;;;;;:ccccccccc,.'c,     ",
                                            "Ol;......................................;l'      ",};
            p9 = new string[18] {  "                                                  ",
                                            "                              ,ddoodd,            ",
                                            "                         .cc' ,ooccoo,'cc.        ",
                                            "                      .ccldo;...',,...;oxdc.      ",
                                            "                   .,,:cc;.,'..;lol;;,'..lkl.     ",
                                            "                  .dOc';:ccl;..;dl,.''.....oc     ",
                                            "                .,lc',cdddddlccld;.,;c::'..,cc:.  ",
                                            "                cNo..:ddddddddddd;':clll;,c,';xc  ",
                                            "               .lo;,clddddddddddd;':clll;:kc..;'  ",
                                            "             .,c;..:ddddddddddddd:';clll,;ll,..   ",
                                            "             ;Oc..';:ldddddddddddl,.,c:;';dd;..   ",
                                            "           .''',:c:,'cdddddddddddo:,''..'cdd;..   ",
                                            "         .cdc';lddd:';lddddddddddddd;.';lddl,..   ",
                                            "      .,;::;,cdddddol;;lllllodddddddlcldddd:.'l;  ",
                                            "     .dOc..,lddddddddlcc:;'';cclddddddddddd;;ll.  ",
                                            "   .coc,;::ldddddddddddddlcccc:ldddddddddl:,cO;   ",
                                            ",xl::,..,cccccccccccccccccccccccccccccccc:;':xx,  ",
                                            "cNd.........................................;lOc  ",};
        }
        public static (int, int) GetCirclePoint(int a, double radius, int cX, int cY) {
            double angle = 2 * Math.PI / 100 * -a;
            int newX = (int)(cX + radius * Math.Cos(angle));
            int newY = (int)(cY + radius * Math.Sin(angle));
            return (newX, newY);
        }
        public string[] getParrotFrame(int frame) {
            switch (frame) {
                case 0:
                    return p0;
                case 1:
                    return p1;
                case 2:
                    return p2;
                case 3:
                    return p3;
                case 4:
                    return p4;
                case 5:
                    return p5;
                case 6:
                    return p6;
                case 7:
                    return p7;
                case 8:
                    return p8;
                case 9:
                    return p9;
                default:
                    throw new ArgumentException("Only 9 frames exists, you entered " + frame);
            }
        }
    }

    internal class Program {
        static int sillyOffset = 0;
        static int cWidth = Console.WindowWidth, cHeight = Console.WindowHeight;
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint lpMode);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        private static void SillyEverything() {
            PARROTIZER p = new PARROTIZER();
            while (true) {
                RenderBorder();
                int offset = 0;
                Console.CursorVisible = false;
                Process[] processlist = Process.GetProcesses();
                for (int i = 0; i < 18; i++) {
                    Console.SetCursorPosition(35, 8 + i);
                    Console.Write(Rainbow.stringToRainbow(p.getParrotFrame(sillyOffset)[i], sillyOffset));
                }
                offset += 5;
                foreach (Process process in processlist) {
                    if (!String.IsNullOrEmpty(process.MainWindowTitle)) {
                        (int x, int y) = PARROTIZER.GetCirclePoint(offset, 140, (1920 / 2) - WindowUtility.GetWindowSize(process.MainWindowHandle).Width / 2, (1080 / 2) - WindowUtility.GetWindowSize(process.MainWindowHandle).Height / 2);
                        WindowUtility.SetPosition(x, y, process.MainWindowHandle);
                    }
                }
            }
        }
        private static void RenderBorder() {
            Console.SetCursorPosition(0, 0);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cWidth; i++) {
                sb.Append("#");
            }
            Console.Write(sb);
            Console.SetCursorPosition(0, cHeight - 1);
            Console.Write(sb);
            sb.Clear();
            for (int i = 0; i < cHeight; i++) {
                if (i == cHeight - 1) {
                    sb.Append("#");
                } else {
                    sb.Append("#\n");
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(sb);
            for (int i = 0; i < cHeight; i++) {
                Console.SetCursorPosition(cWidth - 1, i);
                Console.Write('#');
            }
        }
        public static void Main(string[] args) {
            PARROTIZER p = new PARROTIZER();
            int offset = 0;
            System.Timers.Timer sillyTimer = new System.Timers.Timer(50);
            sillyTimer.Start();
            sillyTimer.Elapsed += SillyTimer_Elapsed;
            SizingFix.SizingFix.init();
            FreezeFix.FreezeFix.init();
            IntPtr old = IntPtr.Zero;
            Console.SetWindowSize(120, 30);
            Vt100Test.Program.init();
            Process[] processlist = Process.GetProcesses();
            while (true) {
                if (offset % 100 == 0) {
                    if (processlist.Length != Process.GetProcesses().Length) {
                        processlist = Process.GetProcesses();
                    }
                }
                RenderBorder();
                Console.CursorVisible = false;
                WindowUtility.SetForegroundWindow(WindowUtility.GetConsoleWindow());
                (int x, int y) = PARROTIZER.GetCirclePoint(offset, 140, (1920 / 2) - WindowUtility.GetWindowSize(WindowUtility.GetForegroundWindow()).Width / 2, (1080 / 2) - WindowUtility.GetWindowSize(WindowUtility.GetForegroundWindow()).Height / 2);
                WindowUtility.SetPosition(x, y, WindowUtility.GetForegroundWindow());
                for (int i = 0; i < 18; i++) {
                    Console.SetCursorPosition(35, 8 + i);
                    Console.Write(Rainbow.stringToRainbow(p.getParrotFrame(sillyOffset)[i], sillyOffset));
                }
                foreach (Process process in processlist) {
                    if (!String.IsNullOrEmpty(process.MainWindowTitle)) {
                        (int x2, int y2) = PARROTIZER.GetCirclePoint(offset, 140, (1920 / 2) - WindowUtility.GetWindowSize(process.MainWindowHandle).Width / 2, (1080 / 2) - WindowUtility.GetWindowSize(process.MainWindowHandle).Height / 2);
                        WindowUtility.SetPosition(x2, y2, process.MainWindowHandle);
                    }
                }
                Console.SetCursorPosition(53, 2);
                Console.Write("boowomp");
                Console.SetCursorPosition(101, 28);
                Console.Write("made by Braydon :)");
                offset++;
            }
        }

        private static void SillyTimer_Elapsed(object? sender, ElapsedEventArgs e) {
            sillyOffset++;
            sillyOffset = sillyOffset % 10;
        }
    }
}

/* 
if (WindowUtility.GetForegroundWindow() != WindowUtility.GetConsoleWindow()) {
    old = WindowUtility.GetForegroundWindow();
    WindowUtility.SetForegroundWindow((old == IntPtr.Zero) ? WindowUtility.GetConsoleWindow() : old);
}
*/