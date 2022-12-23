use std::collections::HashSet;

pub fn resolve_part_1(string: &str) -> String {
    return string.lines()
        .map(line_to_ranges)
        .map(ranges_to_sets)
        .map(are_overlapped)
        .map(to_number)
        .sum::<u64>()
        .to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    return string.lines()
        .map(line_to_ranges)
        .map(ranges_to_sets)
        .map(are_not_overlapped)
        .map(to_number)
        .sum::<u64>()
        .to_string();
}

type Ranges = ((u64, u64), (u64, u64));
fn line_to_ranges(line: &str) -> Ranges {
    let mut parsed_lines = line.split(',')
    .map(|pair| {
        let mut numbers = pair.split('-').map(|n| n.parse::<u64>().unwrap());
        return (
            numbers.next().unwrap(),
            numbers.next().unwrap()
        );
    });
    return (
        parsed_lines.next().unwrap(),
        parsed_lines.next().unwrap(),
    )
}

type Sets = (HashSet<u64>, HashSet<u64>);
fn ranges_to_sets(ranges: Ranges) -> Sets {
    return (
        HashSet::from_iter(ranges.0.0..=ranges.0.1),
        HashSet::from_iter(ranges.1.0..=ranges.1.1)
    )
}

fn are_overlapped((first, second): Sets) -> bool {
    first.is_subset(&second) || second.is_subset(&first)
}

fn are_not_overlapped((first, second): Sets) -> bool {
    first.intersection(&second).collect::<Vec<_>>().len() > 0
}

fn to_number(are_overlapped: bool) -> u64 {
    are_overlapped as u64
}