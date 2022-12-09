use std::{path::Path, collections::VecDeque};

pub fn resolve_part_1(string: &str) -> &str {
    let stacks = initialize_stacks(string);
    for stack in stacks {
        for item in stack.iter() {
            println!("{}", *item as char);
        }
        println!("");
    }
    return "";
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