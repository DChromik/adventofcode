module Program

open System.IO

[<EntryPoint>]
let main _args =
    printfn "Main started"

    // let part1 = File.ReadLines "./day1.txt" |> Day1.resolvePart1
    //
    // printfn "%d" part1
    //
    // let part2 = File.ReadLines "./day1.txt" |> Day1.resolvePart2
    //
    // printfn "%d" part2
    //
    let d1p1 = File.ReadLines "./day2.txt" |> Day2.resolvePart1

    printfn "%d" d1p1

    let d1p2 = File.ReadLines "./day2.txt" |> Day2.resolvePart2

    printfn "%d" d1p2

    0
