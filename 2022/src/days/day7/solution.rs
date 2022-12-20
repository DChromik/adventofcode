pub fn resolve_part_1(string: &str) -> String {
    let mut directories = Vec::new();
    for line in string.lines() {
        let split_line = line.split(' ').collect::<Vec<_>>();
        if is_command(split_line[0]) {
            if split_line[1] == "cd" && split_line[2] != ".." {
                directories.push(Directory::new());
            } else if split_line[1] == "cd" {
                let left_directory = directories.pop().unwrap();
                let current_directory = directories.last_mut().unwrap();
                current_directory.add_sub_directory(&left_directory);
            }
        } else {
            if split_line[0] == "dir" {
                continue;
            }
            let current_directory = directories.last_mut().unwrap();
            let size = split_line[0].parse::<usize>().unwrap();
            current_directory.add_file(size);
        }
    }
    return String::from("Not implemented");
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

    fn add_file(self: &mut Self, size: usize) {
        self.size += size;
    }
    
    fn add_sub_directory(self: &mut Self, sub_directory: &Directory) {
        self.size += sub_directory.size;
    }
}