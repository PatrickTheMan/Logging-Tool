using C = System.Console;
using CC = System.ConsoleColor;
#if DEBUG
using D = System.Diagnostics.Debug;
#endif

namespace LoggingTool {
    public static class Logger {

        /// <summary>
        /// List of Colors used for writing to the console. <br/>
        /// Available Colors:<br/>
        /// DarkBlue        <br/>
        /// DarkGreen       <br/>
        /// DarkCyan        <br/>
        /// DarkMagenta     <br/>
        /// DarkYellow      <br/>
        /// DarkGray        <br/>
        /// Black           <br/>
        /// Blue            <br/>
        /// Green           <br/>
        /// Cyan            <br/>
        /// Magenta         <br/>
        /// Yellow          <br/>
        /// Gray            <br/>
        /// Red             <br/>
        /// White           <br/>
        ///                 <br/>
        /// Specials:       <br/>
        /// Warning: Red    <br/>
        /// Info: Yellow    <br/>
        /// Success: Green  <br/>
        /// Uncertain: Yellow<br/>
        /// </summary>
        public enum Color {
            Black,
            DarkGray,
            DarkBlue,
            DarkGreen,
            DarkCyan,
            DarkRed,
            DarkMagenta,
            DarkYellow,

            Gray,
            Blue,
            Green,
            Cyan,
            Red,
            Magenta,
            Yellow,
            White,


            Warning,
            Info,
            Success,
            Failure,
            Uncertain,
        }

        private static readonly Dictionary<Color, CC> _colors = new() {
            { Color.Black , CC.Black },
            { Color.DarkGray, CC.DarkGray },
            { Color.DarkBlue,CC.DarkBlue },
            { Color.DarkGreen, CC.DarkGreen },
            { Color.DarkCyan, CC.DarkCyan },
            { Color.DarkRed, CC.DarkRed },
            { Color.DarkMagenta, CC.DarkMagenta },
            { Color.DarkYellow, CC.DarkYellow },
            { Color.Gray, CC.Gray },
            { Color.Blue, CC.Blue },
            { Color.Green, CC.Green },
            { Color.Cyan, CC.Cyan },
            { Color.Red, CC.Red },
            { Color.Magenta, CC.Magenta },
            { Color.Yellow, CC.Yellow },
            { Color.White, CC.White },


            { Color.Warning, CC.Red },
            { Color.Info, CC.Yellow },
            { Color.Success, CC.Green },
            { Color.Failure, CC.DarkRed },
            { Color.Uncertain, CC.DarkYellow }
        };

        private static string filename = string.Empty;

        private static bool _initialized = false;


        /// <summary>
        /// Initializes a Log File, allowing the .Log() and .LogLine() methods to write to a file.
        /// </summary>
        public static void Init() {
            TimeOnly dt = TimeOnly.FromDateTime(DateTime.Now);

            if (!Directory.Exists("C:\\B2S\\Logs"))
                Directory.CreateDirectory("C:\\B2S\\Logs");

            filename = "C:\\B2S\\Logs\\Log " + dt.ToString() + ".txt";
            _initialized = true;
        }

        /// <summary>
        /// Writes a string to the console only.
        /// </summary>
        public static void Write(string message = "", Color color = Color.White) {
            C.ForegroundColor = _colors[color];
            if (!message.EndsWith(' '))
                message += ' ';
            C.Write(message);
            C.ForegroundColor = _colors[Color.White];
        }

        /// <summary>
        /// Writes a Line to the console only.
        /// </summary>
        public static void WriteLine(string message = "", Color color = Color.White) {
            C.ForegroundColor = _colors[color];
            C.WriteLine(message);
            C.ForegroundColor = _colors[Color.White];
        }


        /// <summary>
        /// Logs a Line to the console, the debug console if in DEBUG config and to file if Init() has been run
        /// </summary>
        public static void Log(string message = "", Color color = Color.White) {

            string intro = GetTime();
            Write(intro);

            switch (color) {
                case Color.Warning:
                    intro += "[Warning!] ";
                    Write("[Warning!] ", color);
                    WriteLine(message);
                    break;
                case Color.Info:
                    intro += "[Information] ";
                    Write("[Information] ", color);
                    WriteLine(message);
                    break;
                case Color.Success:
                    intro += "[Success!] ";
                    Write("[Success!] ", color);
                    WriteLine(message);
                    break;
                case Color.Failure:
                    intro += "[Failure!] ";
                    Write("[Failure!] ", color);
                    WriteLine(message);
                    break;
                case Color.Uncertain:
                    intro += "[Notify] ";
                    Write("[Notify] ", color);
                    WriteLine(message);
                    break;
                default:
                    WriteLine(message, color);
                    break;
            }


#if DEBUG
            DebugLine(intro + message);
#endif
            if (_initialized) {
                using (StreamWriter writer = new(filename, true)) {
                    writer.Write(intro);
                    writer.WriteLine(message);
                }
            }
        }

#if DEBUG
        /// <summary>
        /// Writes a string to the Debug Console only.
        /// </summary>
        public static void Debug(string message = "") {
            if (!message.EndsWith(' '))
                message += ' ';
            D.Write(message);
        }

        /// <summary>
        /// Writes a Line to the Debug Console only.
        /// </summary>
        public static void DebugLine(string message = "") {
            D.WriteLine(message);
        }
#endif

        private static string GetTime() {
            return '[' + DateTime.Now.TimeOfDay.ToString()[..8] + "] ";
        }
    }
}
