import { Link, useLocation } from "react-router-dom"
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from "@workspace/ui/components/breadcrumb"

export function BreadcrumbComponent() {
  const location = useLocation();
  const paths = location.pathname.split('/').filter(Boolean);

  return (
        <Breadcrumb className="ml-2">
            <BreadcrumbList>
                {paths.map((path, index) => {
                    const isLast = index === paths.length - 1
                    const href = '/' + paths.slice(0, index + 1).join('/')

                    return (
                        <BreadcrumbItem key={path}>
                            {!isLast ? (
                                <>
                                    <BreadcrumbLink asChild>
                                        <Link to={href}>
                                            {path.charAt(0).toUpperCase() + path.slice(1)}
                                        </Link>
                                    </BreadcrumbLink>
                                    <BreadcrumbSeparator />
                                </>
                            ) : (
                                <BreadcrumbPage>
                                    {path.charAt(0).toUpperCase() + path.slice(1)}
                                </BreadcrumbPage>
                            )}
                        </BreadcrumbItem>
                    )
                })}
            </BreadcrumbList>
        </Breadcrumb>
    )
}
