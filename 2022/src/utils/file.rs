use std::fs::read_to_string;

pub fn read_input_file(day: usize) -> String {
    let path = format!("src/days/day{}/input.txt", day);
    return read_to_string(path).unwrap();
}

pub fn read_test_input_file(day: usize) -> String {
    let path = format!("src/days/day{}/input_small.txt", day);
    return read_to_string(path).unwrap();
}
