use std::{path::Path};
use crate::{days::{day1, day2, day3, day4, SOLUTIONS}, utils::read_input_file};

mod days;
mod utils;

fn main() {
    println!("Day 1");
    let result = day1::compute_part_1("src/days/day1/input.txt");
    let top_calories = result[0] + result[1] + result[2];
    println!("  - part 2: {}", top_calories);

    println!("Day 2");
    let result = day2::resolve_part_1("src/days/day2/input.txt");
    println!("  - part 1: {}", result);
    let result = day2::resolve_part_2("src/days/day2/input.txt");
    println!("  - part 2: {}", result);

    println!("Day 3");
    let result = day3::resolve_part_1(Path::new("src/days/day3/input.txt"));
    println!("  - part 1: {}", result);
    let result = day3::resolve_part_2(Path::new("src/days/day3/input.txt"));
    println!("  - part 2: {}", result);

    println!("Day 4");
    let result = day4::resolve_part_1(Path::new("src/days/day4/input.txt"));
    println!("  - part 1: {}", result);
    let result = day4::resolve_part_2(Path::new("src/days/day4/input.txt"));
    println!("  - part 2: {}", result);

    resolve_day(5);
    resolve_day(6);
    resolve_day(7);
}

fn resolve_day(day: usize) {
    println!("Day {}", day);
    let string = read_input_file(day);

    let result = SOLUTIONS[day - 5].0(&string);
    println!("  - part 1: {}", result);

    let result = SOLUTIONS[day - 5].1(&string);
    println!("  - part 2: {}", result);
}