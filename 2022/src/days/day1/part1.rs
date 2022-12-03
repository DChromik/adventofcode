pub fn compute_part_1(file_path: &str) -> Vec<u32> {
    let small_input = std::fs::read_to_string(file_path).unwrap();
    let mut string_array = small_input
        .lines()
        .map(|l| l.parse::<u32>().ok())
        .collect::<Vec<_>>()
        .split(|line| line.is_none())
        .map(|group| group.iter().map(|v| v.unwrap()).sum::<u32>())
        .collect::<Vec<_>>();
    string_array.sort_unstable_by(|a, b| b.cmp(a));
    return string_array;
}
