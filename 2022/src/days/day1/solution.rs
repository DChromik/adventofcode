pub fn resolve_part_1(string: &str) -> String {
    let top_calories = find_top_calories(string);
    return top_calories[0].to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    let top_calories = find_top_calories(string);
    let top_3_summed = top_calories[0] + top_calories[1] + top_calories[2];
    return top_3_summed.to_string();
}

fn find_top_calories(string: &str) -> Vec<usize> {
    let mut vector = string
        .lines()
        .map(|l| l.parse::<usize>().ok())
        .collect::<Vec<_>>()
        .split(|line| line.is_none())
        .map(|group| group.iter().map(|v| v.unwrap()).sum::<usize>())
        .collect::<Vec<_>>();
    vector.sort_unstable_by(|a, b| b.cmp(a));
    return vector;
}