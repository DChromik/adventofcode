use std::{path::Path, collections::VecDeque, slice::Iter};

pub fn resolve_part_1(string: &str) -> String {
    let mut stacks = initialize_stacks(string);
    for instructions in get_instructions(string) {
        let (amount, from, to) = parse_instructions(instructions);
        for _index in 0..amount {
            if !stacks[from].is_empty() {
                let item = stacks[from].pop_back().unwrap();
                stacks[to].push_back(item)
            }
        }
    }
    return get_first_items(stacks.iter());
}

pub fn resolve_part_2(_path: &Path) -> u64 {
    return 0;
}

fn initialize_stacks(string: &str) -> Vec<VecDeque<u8>> {
    let stack_count = get_stack_count(string);
    let mut stacks = vec![VecDeque::new(); stack_count];
    let stack_lines = string.lines()
        .filter(|line| line.contains('['))
        .rev();
    for line in stack_lines {
        for (index, line_index) in (1..line.len()).step_by(4).enumerate() {
            let item = line.as_bytes()[line_index];
            if item != b' ' {
                stacks[index].push_back(line.as_bytes()[line_index])
            }
        }
    }
    return stacks;
}

fn get_stack_count(string: &str) -> usize {
    let line_length = string.lines().nth(0).unwrap().len();
    return (line_length + 1) / 4;
}

fn get_instructions(string: &str) -> Vec<Vec<&str>> {
    return string.lines()
        .filter(|line| line.starts_with("move"))
        .map(|line| line.split(' ').collect::<Vec<&str>>())
        .collect();
}

fn parse_instructions(instructions: Vec<&str>) -> (usize, usize, usize) {
    return (
        instructions[1].parse::<usize>().unwrap(),
        instructions[3].parse::<usize>().unwrap() - 1,
        instructions[5].parse::<usize>().unwrap() - 1,
    )
}

fn get_first_items(stacks: Iter<VecDeque<u8>>) -> String {
    let vec = stacks
        .map(|stack| *stack.back().unwrap_or(&b' ') as char)
        .collect();
    return vec;
}