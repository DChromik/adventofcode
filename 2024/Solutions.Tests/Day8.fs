module Day8

open NUnit.Framework

let input =
    @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47"

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day5.resolvePart1 arr
    Assert.AreEqual(143, result)

[<Test>]
let Test2 () =
    let arr = input.Split('\n')

    let result = Day5.resolvePart2 arr
    Assert.AreEqual(123, result)
