module Day3

open System.Text.RegularExpressions

let pattern = Regex(@"mul\((\d+),(\d+)\)")

let pattern2 = Regex(@"(mul\((\d+),(\d+)\))|(don't\(\))|(do\(\))")

let findMatches (input: string) =
    pattern.Matches input
    |> Seq.cast<Match>
    |> Seq.map (fun m -> int m.Groups[1].Value * int m.Groups[2].Value)
    |> Seq.sum

let findMatches2 (input: string) =
    let mutable isEnabled = true

    pattern2.Matches input
    |> Seq.cast<Match>
    |> Seq.choose (fun m ->
        match m.Groups[0].Value with
        | value when value.StartsWith("mul(") && isEnabled ->
            let n1 = int m.Groups[2].Value
            let n2 = int m.Groups[3].Value
            Some(n1 * n2)
        | "don't()" ->
            isEnabled <- false
            None
        | "do()" ->
            isEnabled <- true
            None
        | _ -> None)
    |> Seq.sum

let resolvePart1 (lines: seq<string>) : int =
    lines |> String.concat "" |> findMatches

let resolvePart2 (lines: seq<string>) : int =
    lines |> String.concat "" |> findMatches2
