pub fn resolve_part_1(string: &str) -> String {
    let mut directories = Vec::new();
    let mut summed_sizes = 0;
    for line in string.lines() {
        let split_line = line.split(' ').collect::<Vec<_>>();
        if is_command(split_line[0]) {
            if split_line[1] == "cd" && split_line[2] != ".." {
                directories.push(Directory::new());
            } else if split_line[1] == "cd" {
                let left_directory = directories.pop().unwrap();
                if left_directory.size <= 100_000 {
                    summed_sizes += left_directory.size;
                }
                println!("Directory: {}", left_directory.size);
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_size(left_directory.size);
            }
        } else {
            if split_line[0] == "dir" {
                continue;
            }
            let current_directory = directories.last_mut().unwrap();
            let size = split_line[0].parse::<usize>().unwrap();
            println!("File: {}", size);
            current_directory.add_size(size);
        }
    }
    while !directories.is_empty() {
        let left_directory = directories.pop().unwrap();
        if left_directory.size <= 100_000 {
            summed_sizes += left_directory.size;
        }
        directories.last_mut().unwrap().add_size(left_directory.size);
    }
    return summed_sizes.to_string();
}

pub fn resolve_part_2(string: &str) -> String {
    return String::from("Not implemented");
}

fn is_command(line: &str) -> bool {
    line.as_bytes()[0] == b'$'
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