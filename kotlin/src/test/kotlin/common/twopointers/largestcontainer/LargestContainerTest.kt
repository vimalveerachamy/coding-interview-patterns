package common.twopointers.largestcontainer

import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class LargestContainerTest {

    private val question = LargestContainer()

    @Test
    fun `Verify solution`() {
        assertEquals(question.solution(listOf(2, 7, 8, 3, 7, 6)), 24)
        assertEquals(question.solution(listOf(1, 8, 6, 2, 5, 4, 8, 3, 7)), 49)
        assertEquals(question.solution(listOf(1, 1)), 1)
        assertEquals(question.solution(listOf()), 0)
        assertEquals(question.solution(listOf(1)), 0)
        assertEquals(question.solution(listOf(0, 1, 0)), 0)
        assertEquals(question.solution(listOf(3, 3, 3, 3)), 9)
        assertEquals(question.solution(listOf(1, 2, 3)), 2)
        assertEquals(question.solution(listOf(3, 2, 1)), 2)
    }
}