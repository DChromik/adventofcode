module Program

open System.IO

[<EntryPoint>]
let main _args =
    printfn "Main started"

    let lines = File.ReadLines "./day1.txt"

    for line in lines do
        printfn "%s" line

    0
