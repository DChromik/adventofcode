module Tests

open NUnit.Framework

let input =
    @"3   4
4   3
2   5
1   3
3   9
3   3"

[<Test>]
let Test1 () =
    let arr = input.Split [| '\n' |]

    let result = Day1.resolvePart1 arr
    Assert.AreEqual(11, result)

[<Test>]
let Test2 () =
    let arr = input.Split [| '\n' |]

    let result = Day1.resolvePart2 arr
    Assert.AreEqual(31, result)
