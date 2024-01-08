import type { Metadata } from 'next'
import './globals.css'
import Navbar from './nav/Navbar'


export const metadata: Metadata = {
  title: 'Create Next App',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>
        <Navbar/>
        <main className='container mx-auto px-5 pt-5'>
        {children}
        </main>
      </body>
    </html>
  )
}
