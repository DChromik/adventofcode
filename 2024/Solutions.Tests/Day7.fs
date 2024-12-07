module Day7

open NUnit.Framework

let input =
    @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day7.resolvePart1 arr
    Assert.AreEqual(3749, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day7.resolvePart2 arr
    Assert.AreEqual(0, result)
