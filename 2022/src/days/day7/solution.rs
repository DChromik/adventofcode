pub fn resolve_part_1(string: &str) -> String {
    let mut directories = Vec::new();
    let mut summed_sizes = 0;
    for line in string.lines() {
        let (line_type, value) = parse_line(line);
        match line_type {
            Type::EnterDirectory => {
                directories.push(Directory::new());
            }
            Type::LeaveDirectory => {
                let left_directory = directories.pop().unwrap();
                if left_directory.size <= 100_000 {
                    summed_sizes += left_directory.size;
                }
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_size(left_directory.size);
            }
            Type::File => {
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_size(value.parse().unwrap());
            }
            _ => {}
        }
    }
    for _ in 0..directories.len() {
        let left_directory = directories.pop().unwrap();
        if left_directory.size <= 100_000 {
            summed_sizes += left_directory.size;
        }
        if !directories.is_empty() {
            directories.last_mut().unwrap().add_size(left_directory.size);
        }
    }
    return summed_sizes.to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    const TOTAL_SPACE: usize = 70_000_000;
    const REQUIRED_SPACE: usize = 30_000_000;
    let mut directories = Vec::new();
    let mut directory_sizes = Vec::new();
    for line in string.lines() {
        let (line_type, value) = parse_line(line);
        match line_type {
            Type::EnterDirectory => {
                directories.push(Directory::new());
            }
            Type::LeaveDirectory => {
                let left_directory = directories.pop().unwrap();
                directory_sizes.push(left_directory.size);
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_size(left_directory.size);
            }
            Type::File => {
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_size(value.parse().unwrap());
            }
            _ => {}
        }
    }
    for _ in  0..directories.len() {
        let left_directory = directories.pop().unwrap();
        directory_sizes.push(left_directory.size);
        if !directories.is_empty() {
            directories.last_mut().unwrap().add_size(left_directory.size);
        }
    }
    let free_space = TOTAL_SPACE - directory_sizes.last().unwrap();
    let mut target_directory_size = REQUIRED_SPACE;
    for size in directory_sizes {
        if (size + free_space) >= REQUIRED_SPACE && size < target_directory_size {
            target_directory_size = size;
        }
    }
    return target_directory_size.to_string();
}

enum Type {
    LeaveDirectory,
    EnterDirectory,
    List,
    Dir,
    File,
}

fn is_command(line: &str) -> bool {
    line.as_bytes()[0] == b'$'
}

type ParsedLine = (Type, String);
fn parse_line(line: &str) -> ParsedLine {
    let split_line = line.split(' ').collect::<Vec<_>>();
    if split_line[1] == "cd" {
        if split_line[2] == ".." {
            return (Type::LeaveDirectory, "..".to_string());
        } else {
            return (Type::EnterDirectory, split_line[2].to_string());
        }
    } else if split_line[0] == "dir" {
        return (Type::Dir, split_line[1].to_string());
    } else if split_line[1] == "ls" {
        return (Type::List, "".to_string());
    }
    return (Type::File, split_line[0].to_string());
}

struct Directory {
    size: usize,
}

impl Directory {
    fn new() -> Self {
        Self { size: 0 }
    }

    fn add_size(self: &mut Self, size: usize) {
        self.size += size;
    }
}