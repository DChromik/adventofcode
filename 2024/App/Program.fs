module Program

open System.IO

let days =
    [| (Day1.resolvePart1 >> int64, Day1.resolvePart2 >> int64)
       (Day2.resolvePart1 >> int64, Day2.resolvePart2 >> int64)
       (Day3.resolvePart1 >> int64, Day3.resolvePart2 >> int64)
       (Day4.resolvePart1 >> int64, Day4.resolvePart2 >> int64)
       (Day5.resolvePart1 >> int64, Day5.resolvePart2 >> int64)
       (Day6.resolvePart1 >> int64, Day6.resolvePart2 >> int64)
       (Day7.resolvePart1, Day7.resolvePart2)
       (Day8.resolvePart1 >> int64, Day8.resolvePart2 >> int64)
       (Day9.resolvePart1 >> int64, Day9.resolvePart2 >> int64)
       (Day10.resolvePart1 >> int64, Day10.resolvePart2 >> int64)
       (Day11.resolvePart1 >> int64, Day11.resolvePart2 >> int64) |]

[<EntryPoint>]
let main args =
    if args.Length < 1 then
        printfn "Day missing, example: 'dotnet run 1' for day 1"

    let day = args.[0]

    printfn $"Resolving Day {day}"

    let (resolvePart1, resolvePart2) = days.[(int day) - 1]

    let part1 = File.ReadLines $"./day{day}.txt" |> resolvePart1
    let part2 = File.ReadLines $"./day{day}.txt" |> resolvePart2

    printfn $"Part 1: {part1}"
    printfn $"Part 2: {part2}"

    0
