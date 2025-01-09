data class TrieNode(
    var isWord: Boolean = false,
    val children: HashMap<Char, TrieNode> = hashMapOf()
)