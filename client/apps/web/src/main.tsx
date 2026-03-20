import { StrictMode } from "react"
import { createRoot } from "react-dom/client"

import "@workspace/ui/globals.css"
import { ThemeProvider } from "@/components/theme-provider.tsx"
import { RouterProvider } from "react-router-dom"
import { router } from "./features/auth/router/index.tsx"

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <ThemeProvider>
        <RouterProvider router={router} />
    </ThemeProvider>
  </StrictMode>
)
