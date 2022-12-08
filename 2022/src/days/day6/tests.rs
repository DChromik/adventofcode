#[cfg(test)]
mod tests {
    use crate::days::day6;
    
    const STRINGS: [&str; 5] = [
        "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
        "bvwbjplbgvbhsrlpgdmjqwftvncz",
        "nppdvjthqldpwncqszvftbrmjlhg",
        "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",
        "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",
    ];
    
    const RESULTS_1: [usize; 5] = [7, 5, 6, 10, 11];
    const RESULTS_2: [usize; 5] = [19, 23, 23, 29, 26];

    #[test]
    fn should_compute_part_1() {
        for (index, string) in STRINGS.iter().enumerate() {
            let result = day6::resolve_part_1(string);
            assert_eq!(result, RESULTS_1[index], "Testing string {}", index + 1);
        }
    }

    #[test]
    fn should_compute_part_2() {
        for (index, string) in STRINGS.iter().enumerate() {
            let result = day6::resolve_part_2(string);
            assert_eq!(result, RESULTS_2[index], "Testing string {}", index + 1);
        }
    }
}