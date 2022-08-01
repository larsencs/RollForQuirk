import React from "react"
import {Routes, Route, Outlet, Navigate} from "react-router-dom"
import { CharacterList } from "./components/character/CharacterList"
import { NewCharacter } from "./components/character/NewCharacter"
import { CharacterDetails } from "./components/character/CharacterDetails"
import { EditCharacter } from "./components/character/EditCharacter"
import { Login } from "./components/auth/Login"
import { Register } from "./components/auth/Register"

export const ApplicationViews = ({isLoggedIn, getLoggedInUser}) => {


    return (
    
    <Routes>
        <Route path="/">
            <Route index element={isLoggedIn? <CharacterList getLoggedInUser={getLoggedInUser}/> : <Navigate to="/login"/>}/>
            <Route path="/create" element={<NewCharacter getLoggedInUser={getLoggedInUser}/>}/>
            <Route path=":id/details" element={<CharacterDetails/>}/>
            <Route path=":id/edit" element={<EditCharacter/>}/>
            <Route path="*" element={<p>These are not the droids you're looking for...</p>}/>
        </Route>

        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Register/>}/>
    </Routes>
    
    )
}