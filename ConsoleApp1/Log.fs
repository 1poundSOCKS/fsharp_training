module Log

open System.IO

let GetLogFilePath = "c:\\dev\\tmp\\log.txt"
let GetDateTimeString ( now : System.DateTime ) = now.ToString("yyyy-MM-dd") + " " + now.ToLongTimeString()
let GetCurrentLogDateTime = GetDateTimeString System.DateTime.Now
let WriteMsg text = File.AppendAllLines(GetLogFilePath, [GetCurrentLogDateTime + " " + text])