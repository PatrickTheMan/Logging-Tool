/*
 * Showcase Run for the State of the Art Logger!!
 * This is meant to serve as a tutorial for how to use the features of this logger
 */
using LoggingTool;

Logger.Log("Showcase Program for the Logging Tool.");
Logger.Log("This tool allows for simple logging to files and consoles.");
Logger.Log("System.Console printing also supports colored outputs.");
Logger.Log("The Available Methods are:");
Logger.Log("Logger.Log(string,color);", Logger.Color.Yellow);
Logger.Log("Which writes to all available consoles and a file");
Logger.Log("Logger.Write(string,color);", Logger.Color.Black);
Logger.Log("Which writes to the System.Console and formats code based on the provided color");
Logger.Log("Logger.WriteLine(string,color);", Logger.Color.Yellow);
Logger.Log("Which does the same thing as the previous method but includes a linebreak");
Logger.WriteLine("Here is a Log written exclusively to the Console!");

Logger.Log("These two methods implement Coloring, Available colors are:");
Logger.Log("DarkGray", Logger.Color.DarkGray);
Logger.Log("DarkBlue", Logger.Color.DarkBlue);
Logger.Log("DarkGreen", Logger.Color.DarkGreen);
Logger.Log("DarkCyan", Logger.Color.DarkCyan);
Logger.Log("DarkRed", Logger.Color.DarkRed);
Logger.Log("DarkMagenta", Logger.Color.DarkMagenta);
Logger.Log("DarkYellow", Logger.Color.DarkYellow);
Logger.Log("Black", Logger.Color.Black);

Logger.Log("Gray", Logger.Color.Gray);
Logger.Log("Blue", Logger.Color.Blue);
Logger.Log("Green", Logger.Color.Green);
Logger.Log("Cyan", Logger.Color.Cyan);
Logger.Log("Red", Logger.Color.Red);
Logger.Log("Magenta", Logger.Color.Magenta);
Logger.Log("Yellow", Logger.Color.Yellow);
Logger.Log("White", Logger.Color.White);

Logger.Log("As Well as the special \"colors\":");
Logger.Log("Warning", Logger.Color.Warning);
Logger.Log("Info", Logger.Color.Info);
Logger.Log("Success", Logger.Color.Success);
Logger.Log("Failure", Logger.Color.Failure);
Logger.Log("Uncertain", Logger.Color.Uncertain);

Logger.Log("If You run in the DEBUG config, you can use the following methods:");
Logger.Log("Logger.Debug(string);", Logger.Color.Yellow);
Logger.Log("Which writes to the Debug console");
Logger.Log("Logger.DebugLine(string);", Logger.Color.Yellow);
Logger.Log("Which does the same thing as the previous method but includes a linebreak");

#if DEBUG
Logger.DebugLine("Here is a Log written to Debug!");
#endif

Logger.Init();
Logger.Log("Here is a Log written to Everything, including the Log file!");
