pub fn compute_part_1(file_path: &str) -> Vec<i32> {
    let small_input = std::fs::read_to_string(file_path)
        .expect("Should have been able to read a file.");
    let string_array = small_input.split("\n");
    let mut highest_calories = vec![0];
    let mut current_elf_calories = 0;
    for substr in string_array {
        let trimmed = substr.trim();
        if trimmed.len() == 0 {
            let mut insert_index = 0;
            for (index, calories) in highest_calories.iter().enumerate() {
                if calories < &current_elf_calories {
                    insert_index = index;
                    break;
                }
            }
            highest_calories.insert(insert_index, current_elf_calories);
            current_elf_calories = 0;
        } else {
            let calories = trimmed.parse::<i32>()
                .expect("Should have parsed calories string");
            current_elf_calories += calories;
        }
    }
    return highest_calories;
}
