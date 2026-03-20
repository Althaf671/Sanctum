import { Separator } from "@workspace/ui/components/separator";
import { useEffect, useState } from "react";

export function Clock() {
    const [now, setNow] = useState(new Date());

    useEffect(() => {
        const interval = setInterval(() => {
            setNow(new Date())
        }, 1000)

        return () => clearInterval(interval)
    }, []);

    const date = now.toLocaleDateString('id-ID', {
        weekday: 'long',
        day: 'numeric',
        month: 'long',
        year: 'numeric'
    });

    const time = now.toLocaleTimeString('id-ID', {
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    });

    return (
        <div className="flex ml-auto gap-1 text-xs opacity-[60%]">
            <span>{time}</span>
            <Separator className="mx-1" orientation="vertical" />
            <span>{date}</span>
        </div>
    );
}