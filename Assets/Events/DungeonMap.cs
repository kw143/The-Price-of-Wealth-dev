using System.Collections.Generic;

public class DungeonMap {
	
	//AdjacencyList of First Node, Second Node. Node : Monobehavior probably
	//Node contains these variables: bool cleared, Event contents
	//This class has methods BFS, GetReachable, position
	
	public string position;
	public string previousPosition;
	public Dictionary<string, AdjacencyList> edges;
	public MapViewer unityView;
	public Dictionary<string, bool> cleared;
	public Dictionary<string, Event> eventMap;
	
	public DungeonMap (string start, Dictionary<string, AdjacencyList> edges, Dictionary<string, Event> eventMap) {
		position = start;
		previousPosition = start;
		this.edges = edges;
		this.eventMap = eventMap;
		cleared = new Dictionary<string, bool>();
		foreach (string s in edges.Keys) {
			cleared.Add(s, false);
		}
	}
	
	public void BFS (string first, string last) {
		
	}
	
	public void BFS(string destination) {
		BFS(position, destination);
	}
	
	public List<string> GetReachable () {
		Queue<string> queue = new Queue<string>();
		List<string> visited = new List<string>();
		queue.Enqueue(position);
		while (queue.Count > 0) {
			string current = queue.Dequeue();
			if (!visited.Contains(current)) {
				visited.Add(current);
				if (cleared[current]) {
					AdjacencyList neighbors = edges[current];
					foreach (string s in neighbors.destinations) {
						queue.Enqueue(s);
					}
				}
			}
		}
		return visited;
	}
	
	public void SetPosition(string pos) {
		previousPosition = position;
		position = pos;
	}
}