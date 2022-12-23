use crate::{days::{SOLUTIONS}, utils::read_input_file};

mod days;
mod utils;

fn main() {
    // println!("Day 1");
    // let result = day1::compute_part_1("src/days/day1/input.txt");
    // let top_calories = result[0] + result[1] + result[2];
    // println!("  - part 2: {}", top_calories);

    resolve_day(2);
    resolve_day(3);
    resolve_day(4);
    resolve_day(5);
    resolve_day(6);
    resolve_day(7);
    resolve_day(8);
}

fn resolve_day(day: usize) {
    println!("Day {}", day);
    let string = read_input_file(day);

    let result = SOLUTIONS[day - 2].0(&string);
    println!("  - part 1: {}", result);

    let result = SOLUTIONS[day - 2].1(&string);
    println!("  - part 2: {}", result);
}