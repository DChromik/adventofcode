use std::{path::Path, fs::read_to_string};

pub fn resolve_part_1(path: &Path) -> u64 {
    let file = read_to_string(path).unwrap();
    let summed_priorities = file.lines()
        .map(split_in_half)
        .map(find_common_item)
        .map(to_priority)
        .sum::<u64>();
    return summed_priorities;
}

pub fn resolve_part_2(_path: &Path) -> u64 {
    return 0;
}

fn split_in_half(line: &str) -> (&str, &str) {
    return line.split_at(line.len() / 2)
}

fn find_common_item(pack: (&str, &str)) -> u8 {
    let index = pack.0
        .find(|character| pack.1.find(character).is_some())
        .unwrap();
    return pack.0.as_bytes()[index];
}

fn to_priority(item: u8) -> u64 {
    if item >= b'a' && item <= b'z' {
        return (item - b'a' + 1) as u64;
    }
    return (item - b'A' + 27) as u64;
}