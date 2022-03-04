# [1,2],[1.5,2.5] = 2
# [1,2] [2,2.5] = 1, [1.5,2.5] [2,2.5] = 2  

# [1,2],[1.5,2.5] = 2
# [1,2] [2,2.5] = 1, [1.5,2.5] [2,2.5] = 2  

# Input = [[1,2],[0.5,2.5],[2,2.5]]    

# Input = [[1,2],[2,3],[3,4]]
# Output = 1 dock

# Input = [[1,2],[1.5,2.5],[1.75, 2.5]]
# Output = 3 dock


class Scheduler:
    def __init__(self):
        pass
    
    def number_of_docks(self, vans):
        
        if len(vans) == 0:
            return 0
        
        N = len(vans)
        dp = [1 for _ in range(N)]
        vans_sorted = sorted(vans, key = k:k[1]) 
        result = 1
        for i in range(1, N):
            for j in range(0, i):
                if self.is_overlap(vans_sorted[j], vans_sorted[i]):
                    dp[i] += 1
            result = max(dp[i], result)
        return result
        
    def is_overlap(self, x, y):
        x0 = x[0]
        x1 = x[1]
        y0 = y[0]
        y1 = y[1]
        
        if (y0 >= x0) and (y0<= x1):
            return True
        
        
        
    