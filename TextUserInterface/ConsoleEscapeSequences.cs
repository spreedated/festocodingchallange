using System;

namespace TextUserInterface
{
    /// <summary>Contains some escape sequences.</summary>
    public static class ConsoleEscapeSequences
    {
        /// <summary>Escape sequence to reset all formatting.</summary>
        public static string ResetAll => "\x1B[0m";
        /// <summary>Escape sequence to bold a text.</summary>
        public static string Bold => "\x1B[1m";
        /// <summary>Escape sequence to reset the bold escape sequence.</summary>
        public static string ResetBold => "\x1B[22m";
        /// <summary>Escape sequence to faint a text.</summary>
        public static string Faint => "\x1B[2m";
        /// <summary>Escape sequence to italic a text.</summary>
        public static string Italic => "\x1B[3m";
        /// <summary>Escape sequence to reset the italic escape sequence.</summary>
        public static string ResetItalic => "\x1B[23m";
        /// <summary>Escape sequence to underline a text.</summary>
        public static string Underline => "\x1B[4m";
        /// <summary>Escape sequence to reset the underline escape sequence.</summary>
        public static string ResetUnderline => "\x1B[24m";
        /// <summary>Escape sequence to let a text blink slow.</summary>
        public static string SlowBlink => "\x1B[5m";
        /// <summary>Escape sequence to let a text blink rapid.</summary>
        public static string RapidBlink => "\x1B[6m";
        /// <summary>Escape sequence to invert colors.</summary>
        public static string InvertColors => "\x1B[7m";
        /// <summary>Escape sequence to reset the invert colors escape sequence.</summary>
        public static string ResetInvertColors => "\x1B[27m";
        /// <summary>Escape sequence to hide a text.</summary>
        public static string HideText => "\x1B[8m";
        /// <summary>Escape sequence to reset the hide text escape sequence.</summary>
        public static string ResetHideText => "\x1B[28m";
        /// <summary>Escape sequence to strikeout a text.</summary>
        public static string Strikeout => "\x1B[9m";
        /// <summary>Escape sequence to reset the strikeout escape sequence.</summary>
        public static string ResetStrikeout => "\x1B[29m";
        /// <summary>Escape sequence for an alert sound.</summary>
        public static string Alert => "\a";
        /// <summary>Escape sequence to reset the foreground color.</summary>
        public static string ResetForegroundColor => "\x1B[39m";
        /// <summary>Escape sequence to set the foreground color to black.</summary>
        public static string ForegroundBlack => "\x1B[30m";
        /// <summary>Escape sequence to set the foreground color to dark red.</summary>
        public static string ForegroundDarkRed => "\x1B[31m";
        /// <summary>Escape sequence to set the foreground color to dark green.</summary>
        public static string ForegroundDarkGreen => "\x1B[32m";
        /// <summary>Escape sequence to set the foreground color to dark yellow.</summary>
        public static string ForegroundDarkYellow => "\x1B[33m";
        /// <summary>Escape sequence to set the foreground color to dark blue.</summary>
        public static string ForegroundDarkBlue => "\x1B[34m";
        /// <summary>Escape sequence to set the foreground color to dark magenta.</summary>
        public static string ForegroundDarkMagenta => "\x1B[35m";
        /// <summary>Escape sequence to set the foreground color to dark cyan.</summary>
        public static string ForegroundDarkCyan => "\x1B[36m";
        /// <summary>Escape sequence to set the foreground color to gray.</summary>
        public static string ForegroundGray => "\x1B[37m";
        /// <summary>Escape sequence to set the foreground color to dark gray.</summary>
        public static string ForegroundDarkGray => "\x1B[90m";
        /// <summary>Escape sequence to set the foreground color to red.</summary>
        public static string ForegroundRed => "\x1B[91m";
        /// <summary>Escape sequence to set the foreground color to green.</summary>
        public static string ForegroundGreen => "\x1B[92m";
        /// <summary>Escape sequence to set the foreground color to yellow.</summary>
        public static string ForegroundYellow => "\x1B[93m";
        /// <summary>Escape sequence to set the foreground color to blue.</summary>
        public static string ForegroundBlue => "\x1B[94m";
        /// <summary>Escape sequence to set the foreground color to magenta.</summary>
        public static string ForegroundMagenta => "\x1B[95m";
        /// <summary>Escape sequence to set the foreground color to cyan.</summary>
        public static string ForegroundCyan => "\x1B[96m";
        /// <summary>Escape sequence to set the foreground color to white.</summary>
        public static string ForegroundWhite => "\x1B[97m";
        /// <summary>Escape sequence to reset the background color.</summary>
        public static string ResetBackgroundColor => "\x1B[49m";
        /// <summary>Escape sequence to set the background color to black.</summary>
        public static string BackgroundBlack => "\x1B[40m";
        /// <summary>Escape sequence to set the background color to dark red.</summary>
        public static string BackgroundDarkRed => "\x1B[41m";
        /// <summary>Escape sequence to set the background color to dark green.</summary>
        public static string BackgroundDarkGreen => "\x1B[42m";
        /// <summary>Escape sequence to set the background color to dark yellow.</summary>
        public static string BackgroundDarkYellow => "\x1B[43m";
        /// <summary>Escape sequence to set the background color to dark blue.</summary>
        public static string BackgroundDarkBlue => "\x1B[44m";
        /// <summary>Escape sequence to set the background color to dark magenta.</summary>
        public static string BackgroundDarkMagenta => "\x1B[45m";
        /// <summary>Escape sequence to set the background color to dark cyan.</summary>
        public static string BackgroundDarkCyan => "\x1B[46m";
        /// <summary>Escape sequence to set the background color to gray.</summary>
        public static string BackgroundGray => "\x1B[47m";
        /// <summary>Escape sequence to set the background color to dark gray.</summary>
        public static string BackgroundDarkGray => "\x1B[100m";
        /// <summary>Escape sequence to set the background color to red.</summary>
        public static string BackgroundRed => "\x1B[101m";
        /// <summary>Escape sequence to set the background color to green.</summary>
        public static string BackgroundGreen => "\x1B[102m";
        /// <summary>Escape sequence to set the background color to yellow.</summary>
        public static string BackgroundYellow => "\x1B[103m";
        /// <summary>Escape sequence to set the background color to blue.</summary>
        public static string BackgroundBlue => "\x1B[104m";
        /// <summary>Escape sequence to set the background color to magenta.</summary>
        public static string BackgroundMagenta => "\x1B[105m";
        /// <summary>Escape sequence to set the background color to cyan.</summary>
        public static string BackgroundCyan => "\x1B[106m";
        /// <summary>Escape sequence to set the background color to white.</summary>
        public static string BackgroundWhite => "\x1B[107m";

        public static string GetColor(ConsoleColor color, bool background = false)
            => color switch
            {
                ConsoleColor.Black => background ? BackgroundBlack : ForegroundBlack,
                ConsoleColor.DarkBlue => background ? BackgroundDarkBlue : ForegroundDarkBlue,
                ConsoleColor.DarkGreen => background ? BackgroundDarkGreen : ForegroundDarkGreen,
                ConsoleColor.DarkCyan => background ? BackgroundDarkCyan : ForegroundDarkCyan,
                ConsoleColor.DarkRed => background ? BackgroundDarkRed : ForegroundDarkRed,
                ConsoleColor.DarkMagenta => background ? BackgroundDarkMagenta : ForegroundDarkMagenta,
                ConsoleColor.DarkYellow => background ? BackgroundDarkYellow : ForegroundDarkYellow,
                ConsoleColor.Gray => background ? BackgroundGray : ForegroundGray,
                ConsoleColor.DarkGray => background ? BackgroundDarkGray : ForegroundDarkGray,
                ConsoleColor.Blue => background ? BackgroundBlue : ForegroundBlue,
                ConsoleColor.Green => background ? BackgroundGreen : ForegroundGreen,
                ConsoleColor.Cyan => background ? BackgroundCyan : ForegroundCyan,
                ConsoleColor.Red => background ? BackgroundRed : ForegroundRed,
                ConsoleColor.Magenta => background ? BackgroundMagenta : ForegroundMagenta,
                ConsoleColor.Yellow => background ? BackgroundYellow : ForegroundYellow,
                ConsoleColor.White => background ? BackgroundWhite : ForegroundWhite,
                _ => null,
            };
    }
}
