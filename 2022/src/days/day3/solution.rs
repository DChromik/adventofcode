pub fn resolve_part_1(string: &str) -> String {
    let summed_priorities = string.lines()
        .map(split_in_half)
        .map(find_common_item_in_pack)
        .map(item_to_priority)
        .sum::<u64>();
    return summed_priorities.to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    let summed_priorities = to_grouped_lines(string)
        .iter()
        .map(find_common_item_in_group)
        .map(item_to_priority)
        .sum::<u64>();
    return summed_priorities.to_string();
}

fn split_in_half(line: &str) -> (&str, &str) {
    return line.split_at(line.len() / 2)
}

fn find_common_item_in_pack(pack: (&str, &str)) -> u8 {
    let index = pack.0
        .find(|character| pack.1.find(character).is_some())
        .unwrap();
    return pack.0.as_bytes()[index];
}

fn find_common_item_in_group(group: &(&str, &str, &str)) -> u8 {
    let index = group.0
        .find(|character| {
            group.1.find(character).is_some()
            && group.2.find(character).is_some()
        })
        .unwrap();
    return group.0.as_bytes()[index];
}

fn item_to_priority(item: u8) -> u64 {
    if item >= b'a' && item <= b'z' {
        return (item - b'a' + 1) as u64;
    }
    return (item - b'A' + 27) as u64;
}

fn to_grouped_lines(string: &str) -> Vec<(&str, &str, &str)> {
    let lines = string.lines();
    let mut i = 0;
    let mut groups = Vec::new();
    let mut group = [""; 3];
    for line in lines {
        group[i % group.len()] = line;
        if i % 3 == 2 {
            groups.push((group[0], group[1], group[2]));
        }
        i += 1;
    }
    return groups;
}
