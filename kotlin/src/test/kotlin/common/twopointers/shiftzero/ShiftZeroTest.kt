package common.twopointers.shiftzero

import org.junit.jupiter.api.Test
import kotlin.test.assertContentEquals

class ShiftZeroTest {

    private val question = ShiftZero()

    @Test
    fun `Test solution 1`() {
        val input = intArrayOf(0, 5, 4, 0, 4, 5, 1, 2, 7, 0)
        question.solution(input)
        assertContentEquals(input, intArrayOf(5, 4, 4, 5, 1, 2, 7, 0, 0, 0))
    }

    @Test
    fun `Test solution 2`() {
        val input = intArrayOf(0, 5, 4, 0, 4, 5, 1, 2, 7, 0)
        question.solution2(input)
        assertContentEquals(input, intArrayOf(5, 4, 4, 5, 1, 2, 7, 0, 0, 0))
    }

}