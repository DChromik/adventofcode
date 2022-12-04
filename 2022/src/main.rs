use std::path::Path;
use crate::days::{day1, day2, day3};

mod days;

fn main() {
    println!("Day 1");
    let result = day1::compute_part_1("src/days/day1/input.txt");
    let top_calories = result[0] + result[1] + result[2];
    println!("  - part 2: {}", top_calories);

    println!("Day2");
    let result = day2::resolve_part_1("src/days/day2/input.txt");
    println!("  - part 1: {}", result);
    let result = day2::resolve_part_2("src/days/day2/input.txt");
    println!("  - part 2: {}", result);

    println!("Day3");
    let result = day3::resolve_part_1(Path::new("src/days/day3/input.txt"));
    println!("  - part 1: {}", result);
}
