﻿using System.Drawing;

namespace LogBox.LogEvents
{
    /// <summary>
    /// Log event image
    /// </summary>
    public class LogEventImage : LogEvent
    {
        /// <summary>
        /// Image of log entry
        /// </summary>
        public Bitmap LogImage { get; set; }

        /// <summary>
        /// Constructor of LogEventImage
        /// </summary>
        /// <param name="logMessage">Message of log entry</param>
        /// <param name="logImage">Image of log entry</param>
        public LogEventImage(string logMessage, Bitmap logImage) : base(LogTypes.IMAGE, logMessage)
        {
            LogImage = (Bitmap)logImage.Clone();
        }
    }
}
