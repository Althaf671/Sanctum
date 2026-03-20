import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../../../../../packages/ui/src/components/card"
import {
  Tabs,
  TabsContent,
  TabsList,
  TabsTrigger,
} from "../../../../../../packages/ui/src/components/tabs"

export function TabsSummary() {
  return (
    <Tabs defaultValue="overview" className="w-[70%] rounded-lg h-[400px]">
        <TabsList className="mb-2">
            <TabsTrigger value="overview">Overview</TabsTrigger>
            <TabsTrigger value="tasks">Tasks</TabsTrigger>
            <TabsTrigger value="schedule">Schedule</TabsTrigger>
        </TabsList>
        <TabsContent value="overview">
            <Card className="h-[100%]">
                <CardHeader>
                    <CardTitle>Overview</CardTitle>
                    <CardDescription>
                        View your key metrics and recent project activity. Track progress
                        across all your active projects.
                    </CardDescription>
                </CardHeader>
                <CardContent className="text-sm text-muted-foreground">
                    You have 12 active projects and 3 pending tasks.
                </CardContent>
            </Card>
      </TabsContent>
      <TabsContent value="tasks">
        <Card className="h-[100%]">
          <CardHeader>
            <CardTitle>Tasks</CardTitle>
            <CardDescription>
              Track performance and user engagement metrics. Monitor trends and
              identify growth opportunities.
            </CardDescription>
          </CardHeader>
          <CardContent className="text-sm text-muted-foreground">
            Page views are up 25% compared to last month.
          </CardContent>
        </Card>
      </TabsContent>
    </Tabs>
  )
}
