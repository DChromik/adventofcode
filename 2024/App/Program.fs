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
    // let d1p1 = File.ReadLines "./day2.txt" |> Day2.resolvePart1
    //
    // printfn "%d" d1p1
    //
    // let d1p2 = File.ReadLines "./day2.txt" |> Day2.resolvePart2
    //
    // printfn "%d" d1p2

    // let d3p1 = File.ReadLines "./day3.txt" |> Day3.resolvePart1
    //
    // printfn "%d" d3p1
    //
    // let d3p2 = File.ReadLines "./day3.txt" |> Day3.resolvePart2
    //
    // printfn "%d" d3p2

    // let d4p1 = File.ReadLines "./day4.txt" |> Day4.resolvePart1
    //
    // printfn "%d" d4p1
    //
    // let d4p2 = File.ReadLines "./day4.txt" |> Day4.resolvePart2
    //
    // printfn "%d" d4p2

    let d5p1 = File.ReadLines "./day5.txt" |> Day5.resolvePart1

    printfn "%d" d5p1

    let d5p2 = File.ReadLines "./day5.txt" |> Day5.resolvePart2

    printfn "%d" d5p2

    0
