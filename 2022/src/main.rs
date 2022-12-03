use crate::days::day1::part1::compute_part_1;

mod days;

fn main() {
    let result = compute_part_1("src/days/day1/input.txt");
    let top_calories = result[0] + result[1] + result[2];
    println!("{}", top_calories);
}
