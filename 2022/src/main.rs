use std::{path::Path, fs::read_to_string, ops::Add};
use crate::days::{day1, day2, day3, day4, day6, day5};

mod days;

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

    println!("Day 5");
    let path = Path::new("src/days/day5/input.txt");
    let string = read_to_string(path).unwrap();
    let result = day5::resolve_part_1(&string);
    println!("  - part 1: {}", result);
    let result = day5::resolve_part_2(&string);
    println!("  - part 2: {}", result);

    println!("Day 6");
    let path = Path::new("src/days/day6/input.txt");
    let string = read_to_string(path).unwrap();
    let result = day6::resolve_part_1(&string);
    println!("  - part 1: {}", result);
    let result = day6::resolve_part_2(&string);
    println!("  - part 2: {}", result);
}
