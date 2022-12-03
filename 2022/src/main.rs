use crate::day1::compute_day_1;

mod day1;
mod day1test;

fn main() {
    let result = compute_day_1("src/input.txt");
    println!("{}", result);
}
