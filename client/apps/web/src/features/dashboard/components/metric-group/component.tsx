import { HugeiconsIcon } from "@hugeicons/react";
import { 
    Card, 
    CardContent, 
    CardFooter, 
    CardHeader, 
    CardTitle 
} from "@workspace/ui/components/card";
import { metricCard } from "./component.props";

export function MetricGroup() {
    return (
        <div className="flex flex-row w-[70%] mx-0 my-0 justify-between">
            {metricCard.map((item) => (
                <Card className="w-[31.5%] h-[120px]">
                    <CardHeader className="flex items-center gap-2">
                        <HugeiconsIcon 
                            icon={item.icon}
                            style={{ 
                                width: "32px", height: "32px", marginTop: "-2px",
                                backgroundColor: "", borderRadius: "50%", padding: "5px",
                            }} 
                            strokeWidth={1.5}
                        />
                        <CardTitle className="text-[0.9rem]">{item.title}</CardTitle>
                    </CardHeader>
                    <CardContent>{item.curentValue}/{item.targetValue}</CardContent>
                    <CardFooter></CardFooter>
                </Card>
            ))}
        </div>
    );
}