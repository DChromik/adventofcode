module Day10

open NUnit.Framework

let input =
    @"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day10.resolvePart1 arr
    Assert.AreEqual(36, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day10.resolvePart2 arr
    Assert.AreEqual(81, result)
