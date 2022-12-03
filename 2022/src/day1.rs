pub fn compute_day_1(file_path: &str) -> i32 {
    let small_input = std::fs::read_to_string(file_path)
        .expect("Should have been able to read a file.");
    let string_array = small_input.split("\n");
    let mut highest_calories = 0;
    let mut current_elf_calories = 0;
    for substr in string_array {
        let trimmed = substr.trim();
        if trimmed.len() == 0 {
            if highest_calories < current_elf_calories {
                highest_calories = current_elf_calories;
            }
            current_elf_calories = 0;
        } else {
            let calories = trimmed.parse::<i32>()
                .expect("Should have parsed calories string");
            current_elf_calories += calories;
        }
    }
    return highest_calories;
}