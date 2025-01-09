package common.twopointers.shiftzero

import org.junit.jupiter.api.Test
import kotlin.test.assertContentEquals

class ShiftZeroTest {

    private val question = ShiftZeroToTheEnd()

    @Test
    fun `Test solution`() {
        val input = intArrayOf(0, 5, 4, 0, 4, 5, 1, 2, 7, 0)
        question.solution(input)
        assertContentEquals(intArrayOf(5, 4, 4, 5, 1, 2, 7, 0, 0, 0), input)
    }
}