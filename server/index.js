import express from "express"
import { PrismaClient } from "@prisma/client"

const prisma = new PrismaClient()
const app = express()
const PORT = 3000

app.get("/hello" , async (req,res) => {
    req.json({
        message : "hello world"
    })
})



app.listen(PORT,() => console.log(`app start on : http://localhost:${PORT}`))