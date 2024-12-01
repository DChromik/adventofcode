﻿module Program

open System.IO

[<EntryPoint>]
let main _args =
    printfn "Main started"

    let part1 = File.ReadLines "./day1.txt" |> Day1.resolvePart1

    printfn "%d" part1

    let part2 = File.ReadLines "./day1.txt" |> Day1.resolvePart2

    printfn "%d" part2

    0
