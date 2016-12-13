/***************************************************************************\
Module Name:  Program.cs
Project:      Admin
Url:          http://go.beeming.net/2hocTo8

A small app that allows you to run other apps as admin from command line easily.

The MIT License (MIT)

Copyright (c) Gordon Beeming

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
\***************************************************************************/
using System;
using System.Diagnostics;

namespace Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Trim('\"') == "in-admin")
                {
                    if (args.Length > 2)
                    {
                        string workingDirectory = args[1].Trim('\"');
                        string app = args[2].Trim('\"');
                        string arg = string.Empty;
                        if (args.Length > 3)
                        {
                            arg = string.Join(" ", args, 3, args.Length - 2);
                        }
                        var psi = new ProcessStartInfo();
                        psi.WorkingDirectory = workingDirectory;
                        psi.FileName = app;
                        psi.Arguments = arg;
                        Process.Start(psi);
                    }
                }
                else
                {
                    string arg = string.Join(" ", args);
                    var psi = new ProcessStartInfo();
                    psi.WorkingDirectory = Environment.CurrentDirectory;
                    psi.FileName = Process.GetCurrentProcess().MainModule.FileName;
                    psi.Arguments = $@"""in-admin"" ""{Environment.CurrentDirectory}"" {arg}";
                    psi.Verb = "runas";
                    Process.Start(psi);
                }                
            }
        }
    }
}
