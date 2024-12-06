module Day6

open NUnit.Framework

let input =
    @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#..."

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day6.resolvePart1 arr
    Assert.AreEqual(41, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day6.resolvePart2 arr
    Assert.AreEqual(0, result)
