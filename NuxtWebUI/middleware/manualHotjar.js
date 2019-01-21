export default function ({ params, route, redirect }) {
  if (typeof hj === "function" && hj)
  {
    console.log("manually issue hotjar stateChange", route.path)
    hj('stateChange', route.path)
  }  
}