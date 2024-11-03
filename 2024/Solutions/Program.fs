module Program

open System.IO

for line in File.ReadLines "./Program.fs" do
    printfn "%s" line

Day1.resolvePart1 "pathToFile"
