#[cfg(test)]
mod tests {
    use crate::{days::day4::*, utils::read_test_input_file};


    #[test]
    fn should_compute_part_1() {
        let string = &read_test_input_file(4);
        let result = resolve_part_1(string);
        assert_eq!(result, "2");
    }

    #[test]
    fn should_compute_part_2() {
        let string = &read_test_input_file(4);
        let result = resolve_part_2(string);
        assert_eq!(result, "4");
    }
}